import { combineReducers } from 'redux';

import ExampleReducer from './Example/modules/reducer';
import DashboardReducer from './Dashboard/modules/reducer';

export default combineReducers({
  example: ExampleReducer,
  dashboard: DashboardReducer,
});
