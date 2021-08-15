import { all, put, call, spawn, takeLatest } from "redux-saga/effects";
import debug from 'debug';
import proxies from 'util/proxies';
import * as actions from './actions';

const log = debug('saga:dashboard');

function* getMetricsData() {
  try {
    log('Retrieving metrics...');
    const result = yield call(proxies.getMetrics);
    console.log(result);
    yield put(actions.exampleAction(result.data));
  } catch(err) {
    log('Error retrieving metrics');
  }
}

export default [
  takeLatest(actions.fetchMetrics, getMetricsData),
];