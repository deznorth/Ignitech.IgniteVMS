import { put, call, takeLatest } from "redux-saga/effects";
import debug from 'debug';
import proxies from 'util/proxies';
import * as actions from './actions';

const log = debug('saga:login');

function* getUserLogin({ payload: {username, password} }) {
  try {
    log('Retrieving User Data...');
    yield put(actions.signingIn());
    const result = yield call(proxies.postLogin, {username, password});
    yield put(actions.signedIn(result.data));
  } catch(err) {
    log('Error retrieving user login data');
  }
}

export default [
  takeLatest(actions.login, getUserLogin),
];