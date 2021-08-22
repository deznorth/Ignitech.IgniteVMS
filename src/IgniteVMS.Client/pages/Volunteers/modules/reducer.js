import { handleActions } from 'redux-actions';
import * as actions from './actions';

const INITIAL_STATE = {
  loading: false,
  volunteerData: [],
};

export default handleActions({
  [actions.fetchingVolunteers]: state => ({
    ...state,
    loading: true,
    volunteerData: [],
  }),
  [actions.fetchedVolunteers]: (state, { payload }) => ({
    ...state,
    loading: false,
    volunteerData: payload,
  }),
}, INITIAL_STATE);