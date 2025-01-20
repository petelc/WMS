import { LockOutlined } from '@mui/icons-material';
import {
  Box,
  Button,
  Container,
  Paper,
  TextField,
  Typography,
} from '@mui/material';
import { useForm } from 'react-hook-form';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { LoginSchema } from '../../lib/schemas/LoginSchema';
import { zodResolver } from '@hookform/resolvers/zod';
import { useLazyUserInfoQuery, useLoginMutation } from './accountApi';

export default function LoginForm() {
  const [login, { isLoading }] = useLoginMutation();
  const [fetchUserInfo] = useLazyUserInfoQuery();
  const navigate = useNavigate();
  const location = useLocation();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginSchema>({
    mode: 'onTouched',
    resolver: zodResolver(LoginSchema),
  });

  const onSubmit = async (data: LoginSchema) => {
    await login(data);
    await fetchUserInfo();
    navigate(location.state?.from || '/');
  };

  return (
    <Container component={Paper} maxWidth='sm' sx={{ borderRadius: 3 }}>
      <Box
        display='flex'
        flexDirection='column'
        alignItems='center'
        marginTop='8'
      >
        <LockOutlined sx={{ mt: 3, color: 'secondary.main', fontSize: 40 }} />
        <Typography variant='h5'>Sign in</Typography>
        <Box
          component='form'
          onSubmit={handleSubmit(onSubmit)}
          width='100%'
          display='flex'
          flexDirection='column'
          gap={3}
          marginY={3}
        >
          <TextField
            label='Email'
            type='email'
            fullWidth
            autoFocus
            {...register('email')}
          />
          <TextField
            fullWidth
            label='Password'
            type='password'
            {...register('password')}
            error={!!errors.password}
            helperText={errors.password?.message}
          />
          <Button
            variant='contained'
            color='primary'
            type='submit'
            disabled={isLoading}
          >
            Sign in
          </Button>
          <Typography sx={{ textAlign: 'center' }}>
            Don't have an account?
            <Typography
              component={Link}
              to='/register'
              color='primary'
              sx={{ cursor: 'pointer', ml: 2 }}
            >
              Sign up
            </Typography>
          </Typography>
        </Box>
      </Box>
    </Container>
  );
}
