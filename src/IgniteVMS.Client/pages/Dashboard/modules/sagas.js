import { put, call, takeLatest } from "redux-saga/effects";
import debug from 'debug';
import proxies from 'util/proxies';
import * as actions from './actions';

const log = debug('saga:dashboard');

function* getMetricsData() {
  try {
    log('Retrieving metrics...');
    yield put(actions.fetchingMetrics());
    const result = yield call(proxies.getMetrics);
    yield put(actions.fetchedMetrics(result.data));
  } catch(err) {
    log('Error retrieving metrics');
  }
}

export default [
  takeLatest(actions.fetchMetrics, getMetricsData),
];