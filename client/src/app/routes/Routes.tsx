import { createBrowserRouter, Navigate } from 'react-router-dom';
import App from '../layout/App';
import HomePage from '../../features/home/HomePage';
import RequireAuth from './RequireAuth';
import RequestPage from '../../features/requests/RequestPage';
import AboutPage from '../../features/about/AboutPage';
import ContactPage from '../../features/contact/ContactPage';
import LoginForm from '../../features/account/LoginForm';
import ServerError from '../errors/ServerError';
import NotFound from '../errors/NotFound';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        element: <RequireAuth />,
        children: [{ path: 'requests', element: <RequestPage /> }],
      },
      { path: '', element: <HomePage /> },
      { path: 'about', element: <AboutPage /> },
      { path: 'contact', element: <ContactPage /> },
      { path: 'login', element: <LoginForm /> },

      { path: 'server-error', element: <ServerError /> },
      { path: 'not-found', element: <NotFound /> },
      { path: '*', element: <Navigate replace to='/not-found' /> },
    ],
  },
]);
