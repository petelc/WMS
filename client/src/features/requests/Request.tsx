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
import { useForm } from 'react-hook-form';
import { useCreateRequestMutation } from './requestsApi';
import { handleApiError } from '../../lib/util';
import RequestForm from './RequestForm';
import MandateForm from './MandateForm';
import ImpactForm from './ImpactForm';
import ScopeForm from './ScopeForm';
import { RequestSchema } from '../../lib/schemas/requestSchema';
import dayjs from 'dayjs';
import Confirm from './Confirm';
import { zodResolver } from '@hookform/resolvers/zod';

const steps = [
  'Basic Request Information',
  'Mandate',
  'Impact',
  'Scope',
  'Confirm',
];

export default function Request() {
  const [activeStep, setActiveStep] = useState(0);
  const [skipped, setSkipped] = useState(new Set<number>());

  const { setError } = useForm<RequestSchema>({
    mode: 'onTouched',
    resolver: zodResolver(RequestSchema),
  });
  const [createRequest] = useCreateRequestMutation();
  //const {createRequest} = useCreateRequestMutation();

  // ? Form State
  const [requestData, setRequestData] = useState<RequestSchema>({
    requestTitle: '',
    requestedBy: '',
    department: '',
    explainImpact: '',
    sendToBoard: false,
    approvalStatus: '',
    stakeHolders: '',
    requestDate: dayjs('01/01/2025').toDate(),
    proposedImpDate: dayjs('01/01/2025').toDate(),
    boardDate: dayjs('01/01/2025').toDate(),
    approvalDate: dayjs('01/01/2025').toDate(),
    denialDate: dayjs('01/01/2025').toDate(),
    policies: [],
    relatedProjects: [],
    isNew: true,
    isActive: false,
    requestType: '',
    requestStatus: '',
    priority: '',
    mandateBy: [''],
    mandateTitle: '',
    mandateDescription: '',
    requiredComplianceDate: dayjs('01/01/2025').toDate(),
    codeRuleNums: '',
    internalUserCount: 0,
    externalUserCount: 0,
    newAutomationExplain: '',
    explainCostSavings: '',
    impactedClassifications: [],
    impactedExternalJobTypes: [],
    objectives: '',
    requirements: '',
    resources: '',
  }); // ? Request Data

  // ? Stepper Functions
  const isStepOptional = (step: number) => {
    return step === -1;
  };

  const isStepSkipped = (step: number) => {
    return skipped.has(step);
  };

  const handleNext = () => {
    let newSkipped = skipped;
    // TODO : Add validation
    //console.log('Request Data', requestData);

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

  const handleChange = (
    input: string,
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    if (input === 'mandateBy') {
      const mandateBy = [...requestData.mandateBy];
      if ((e.target as HTMLInputElement).checked) {
        mandateBy.push(e.target.name);
      } else {
        const index = mandateBy.indexOf(e.target.name);
        if (index > -1) {
          mandateBy.splice(index, 1);
        }
      }
      setRequestData({ ...requestData, [input]: mandateBy });
      return;
    }
    setRequestData({ ...requestData, [input]: e.target.value });
  };

  // const createFormData = (items: FieldValues) => {
  //   const formData = new FormData();
  //   for (const key in items) {
  //     formData.append(key, items[key]);
  //   }
  //   return formData;
  // };

  const onRequestSubmit = async () => {
    try {
      //const formData = createFormData(requestData);
      //console.log('Request Data', formData);
      await createRequest(requestData).unwrap();
    } catch (error) {
      console.log(error);
      handleApiError<RequestSchema>(error, setError, ['requestTitle']);
    }
  };

  const formContent = (step: number) => {
    switch (step) {
      case 0:
        return (
          <RequestForm handleChange={handleChange} requestData={requestData} />
        );
      case 1:
        return (
          <MandateForm handleChange={handleChange} requestData={requestData} />
        );
      case 2:
        return (
          <ImpactForm handleChange={handleChange} requestData={requestData} />
        );
      case 3:
        return (
          <ScopeForm handleChange={handleChange} requestData={requestData} />
        );
      case 4:
        return <Confirm requestData={requestData} />;
      default:
        break;
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
                <Box sx={{ flex: '1 1 auto' }}>
                  <Button onClick={handleReset}>Reset</Button>
                </Box>
                <Box sx={{ flex: '1 1 auto' }}>
                  <Button
                    onClick={onRequestSubmit}
                    variant='contained'
                    color='primary'
                  >
                    Submit
                  </Button>
                </Box>
              </Box>
            </>
          ) : (
            <>
              {formContent(activeStep)}

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
