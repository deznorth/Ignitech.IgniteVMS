import { createAction } from 'redux-actions';

const base = 'dashboard/';
const makeAction = action => createAction(`${base}${action}`);

// Shared actions (used by sagas and reducers)
export const fetchingMetrics = makeAction('FETCHING_METRICS');
export const fetchedMetrics = makeAction('FETCHED_METRICS');

// Saga-only actions
export const fetchMetrics = makeAction('FETCH_METRICS');
