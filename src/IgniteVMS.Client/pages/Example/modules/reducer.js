import { handleActions } from 'redux-actions';
import * as actions from './actions';

const INITIAL_STATE = {
  testMessage: null,
};

export default handleActions({
  [actions.exampleAction]: (state, { payload }) => ({
    ...state,
    testMessage: `Message from the example action: ${payload}`,
  }),
}, INITIAL_STATE);
