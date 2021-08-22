import { handleActions } from 'redux-actions';
import * as actions from './actions';

const INITIAL_STATE = {
  loading: false,
  currentUser: null,
};

export default handleActions({
  [actions.signingIn]: state => ({
    ...state,
    loading: true,
    currentUser: null,
  }),
  [actions.signedIn]: (state, { payload }) => ({
    ...state,
    loading: false,
    currentUser: payload,
  }),
}, INITIAL_STATE);