import { useState } from 'react';
import { Cyclone } from '@mui/icons-material';
import {
  Container,
  Paper,
  Box,
  Typography,
  Divider,
  Stepper,
  Step,
  StepLabel,
  Button,
} from '@mui/material';
import { FieldValues, useForm } from 'react-hook-form';
import RequestForm from './RequestForm';
import MandateForm from './MandateForm';
import ImpactForm from './ImpactForm';
import ScopeForm from './ScopeForm';
import { RequestSchema } from '../../lib/schemas/requestSchema';
import { handleApiError } from '../../lib/util';
import { useCreateRequestMutation } from './requestsApi';

const steps = ['Basic Request Information', 'Mandate', 'Impact', 'Scope'];

export default function Request() {
  const [activeStep, setActiveStep] = useState(0);
  const [skipped, setSkipped] = useState(new Set<number>());

  const [requestId, setRequestId] = useState<number>(0);
  const [request, setRequest] = useState<RequestSchema>({
    title: '',
    description: '',
  });
  const { setError } = useForm<RequestSchema>();
  const [createRequest] = useCreateRequestMutation();

  // ? Stepper Functions
  const isStepOptional = (step: number) => {
    return step === 1;
  };

  const isStepSkipped = (step: number) => {
    return skipped.has(step);
  };

  const handleNext = () => {
    let newSkipped = skipped;
    // LEC I think I need to submit the form for each step here and then move to the next step
    if (activeStep === 0) {
      onRequestSubmit(request);
      console.log('Request Form Submitted');
    } else if (activeStep === 1) {
      console.log('Mandate Form Submitted');
    } else if (activeStep === 2) {
      console.log('Impact Form Submitted');
    } else if (activeStep === 3) {
      console.log('Scope Form Submitted');
    }

    if (isStepSkipped(activeStep)) {
      newSkipped = new Set(newSkipped.values());
      newSkipped.delete(activeStep);
    }
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
    setSkipped(newSkipped);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleSkip = () => {
    if (!isStepOptional(activeStep)) {
      throw new Error('You can not skip a step that is not optional.');
    }

    setActiveStep((prevActiveStep) => prevActiveStep + 1);
    setSkipped((prevSkipped) => {
      const newSkipped = new Set(prevSkipped.values());
      newSkipped.add(activeStep);
      return newSkipped;
    });
  };

  const handleReset = () => {
    setActiveStep(0);
  };

  // ? Form Actions
  const createFormData = (items: FieldValues) => {
    const formData = new FormData();
    for (const key in items) {
      formData.append(key, items[key]);
    }

    return formData;
  };

  const onRequestSubmit = async (data: RequestSchema) => {
    console.log(request);
    try {
      const formData = createFormData(data);
      const response = await createRequest(formData).unwrap();
      setRequestId(response.id);
      console.log(requestId);
      console.log('Request Submitted');
    } catch (error) {
      console.error(error);
      handleApiError<RequestSchema>(error, setError, ['title', 'description']);
    }
  };

  return (
    <Container component={Paper} maxWidth='lg' sx={{ borderRadius: 2 }}>
      <Box
        display='flex'
        flexDirection='column'
        alignItems='center'
        marginTop='8'
      >
        <Cyclone sx={{ mt: 3, mb: 2, color: 'secondary.main', fontSize: 40 }} />
        <Typography variant='h5' gutterBottom>
          Submit a New Request
        </Typography>
        <Box sx={{ width: '100%', mt: 4, mb: 4 }}>
          <Divider />
        </Box>
        <Box sx={{ width: '100%', mb: 4 }}>
          <Stepper activeStep={activeStep}>
            {steps.map((label, index) => {
              const stepProps: { completed?: boolean } = {};
              const labelProps: {
                optional?: React.ReactNode;
              } = {};
              if (isStepOptional(index)) {
                labelProps.optional = (
                  <Typography variant='caption'>Optional</Typography>
                );
              }
              if (isStepSkipped(index)) {
                stepProps.completed = false;
              }
              return (
                <Step key={label} {...stepProps}>
                  <StepLabel {...labelProps}>{label}</StepLabel>
                </Step>
              );
            })}
          </Stepper>
          {activeStep === steps.length ? (
            <>
              <Typography sx={{ mt: 2, mb: 1 }}>
                All steps completed - you&apos;re finished
              </Typography>
              <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                <Box sx={{ flex: '1 1 auto' }} />
                <Button onClick={handleReset}>Reset</Button>
              </Box>
            </>
          ) : (
            <>
              <Typography sx={{ mt: 2, mb: 1 }}>
                Step {activeStep + 1}
              </Typography>
              {activeStep === 0 ? (
                <RequestForm />
              ) : activeStep === 1 ? (
                <MandateForm />
              ) : activeStep === 2 ? (
                <ImpactForm />
              ) : activeStep === 3 ? (
                <ScopeForm />
              ) : null}

              <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                <Button
                  color='inherit'
                  disabled={activeStep === 0}
                  onClick={handleBack}
                  sx={{ mr: 1 }}
                >
                  Back
                </Button>
                <Box sx={{ flex: '1 1 auto' }} />
                {isStepOptional(activeStep) && (
                  <Button color='inherit' onClick={handleSkip} sx={{ mr: 1 }}>
                    Skip
                  </Button>
                )}
                <Button onClick={handleNext}>
                  {activeStep === steps.length - 1 ? 'Finish' : 'Next'}
                </Button>
              </Box>
            </>
          )}
        </Box>
      </Box>
    </Container>
  );
}
