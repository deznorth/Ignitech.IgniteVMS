import { createAction } from 'redux-actions';

const base = 'volunteers/';
const makeAction = action => createAction(`${base}${action}`);

// Shared actions (used by sagas and reducers)
export const fetchingVolunteers = makeAction('FETCHING_VOLUNTEERS');
export const fetchedVolunteers = makeAction('FETCHED_VOLUNTEERS');

// Saga-only actions
export const fetchVolunteers = makeAction('FETCH_VOLUNTEERS');