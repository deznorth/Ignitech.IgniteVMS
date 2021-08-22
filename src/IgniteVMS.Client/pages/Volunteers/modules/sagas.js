import { put, call, takeLatest } from "redux-saga/effects";
import debug from 'debug';
import proxies from 'util/proxies';
import * as actions from './actions';

const log = debug('saga:volunteers');

function* getVolunteers() {
  try {
    log('Retrieving volunteers...');
    yield put(actions.fetchingVolunteers());
    const result = yield call(proxies.getAllVolunteers);
    yield put(actions.fetchedVolunteers(result.data));
  } catch(err) {
    log('Error retrieving volunteers');
  }
}

export default [
  takeLatest(actions.fetchVolunteers, getVolunteers),
];