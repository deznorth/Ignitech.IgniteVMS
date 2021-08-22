import { createAction } from 'redux-actions';

const base = 'login/';
const makeAction = action => createAction(`${base}${action}`);

// Shared actions (used by sagas and reducers)
export const signingIn = makeAction('SIGNING_IN');
export const signedIn = makeAction('SIGNED_IN');

// Saga-only actions
export const login = makeAction('LOGIN');