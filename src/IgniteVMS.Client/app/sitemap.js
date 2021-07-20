import { lazy } from 'react';

// Pages
const ThemePage = lazy(() => import(/* webpackChunkName: "ivms-theme" */ 'pages/Theme'));
const ExamplePage = lazy(() => import(/* webpackChunkName: "ivms-example" */ 'pages/Example'));

export const SITEMAP_NAVBAR = {
  // Dashboard: {
  //   name: 'dashboard',
  //   path: '/',
  //   exact: true,
  //   authRequired: true,
  //   // component: StorePage,
  // },
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
};