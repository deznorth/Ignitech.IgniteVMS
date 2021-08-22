import { lazy } from 'react';

// Pages
const ThemePage = lazy(() => import(/* webpackChunkName: "ivms-theme" */ 'pages/Theme'));
const ExamplePage = lazy(() => import(/* webpackChunkName: "ivms-example" */ 'pages/Example'));
const DashboardPage = lazy(() => import(/* webpackChunkName: "ivms-dashboard" */ 'pages/Dashboard'));
const LoginPage = lazy(() => import(/* webpackChunkName: "ivms-login" */ 'pages/Login'));
const VolunteersPage = lazy(() => import(/* webpackChunkName: "ivms-volunteers" */ 'pages/Volunteers'));



export const SITEMAP_NAVBAR = {
  Dashboard: {
    name: 'dashboard',
    path: '/dashboard',
    exact: true,
    authRequired: true,
    component: DashboardPage,
  },
  // Volunteers: {
  //   name: 'volunteers',
  //   path: '/volunteers',
  //   exact: true,
  //   authRequired: true,
  //   // component: AboutPage,
  // },
  // Opportunities: {
  //   name: 'opportunities',
  //   path: '/opportunities',
  //   exact: true,
  //   authRequired: true,
  //   // component: LibraryPage,
  // },
};

export const SITEMAP = {
  ...SITEMAP_NAVBAR,
  Theme: {
    name: 'theme',
    path: '/theme',
    exact: true,
    component: ThemePage,
  },
  Example: {
    name: 'example',
    path: '/',
    exact: true,
    component: ExamplePage,
  },
  Login: {
    name: 'login',
    path: '/login',
    exact: true,
    component: LoginPage,
  },
  Volunteers: {
    name: 'volunteers',
    path: '/volunteers',
    exact: true,
    component: VolunteersPage,
  },
};