import ExampleSagas from './Example/modules/sagas';
import DashboardSagas from './Dashboard/modules/sagas';
import LoginSagas from './Login/modules/sagas';
import VolunteerSagas from './Volunteers/modules/sagas';

export default [
  ...ExampleSagas,
  ...DashboardSagas,
  ...LoginSagas,
  ...VolunteerSagas,
];