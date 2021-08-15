import { handleActions } from 'redux-actions';
import * as actions from './actions';

const INITIAL_STATE = {
  loading: false,
  metrics: null,
};

export default handleActions({
  [actions.fetchingMetrics]: state => ({
    ...state,
    loading: true,
    metrics: null,
  }),
  [actions.fetchedMetrics]: (state, { payload }) => ({
    ...state,
    loading: false,
    metrics: payload,
  }),
}, INITIAL_STATE);