import { combineReducers } from 'redux';

import ExampleReducer from './Example/modules/reducer';
import DashboardReducer from './Dashboard/modules/reducer';
import LoginReducer from './Login/modules/reducer';
import VolunteerReducer from './Volunteers/modules/reducer';

export default combineReducers({
  example: ExampleReducer,
  dashboard: DashboardReducer,
  login: LoginReducer,
  volunteers: VolunteerReducer,
});
