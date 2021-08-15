import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import * as actions from './modules/actions';

const DashboardPage = props => {
  const {
    loading,
    metrics,
    fetchMetrics,
  } = props;

  useEffect(() => {
    fetchMetrics();
  }, []);

  return (
    <div>
      <h1>Hello World!</h1>
      <pre>
        {JSON.stringify(props, null, 2)}
      </pre>
    </div>
  );
};

export default connect(
  state => ({
    ...state.pages.dashboard,
  }), {
    fetchMetrics: actions.fetchMetrics,
  }
)(DashboardPage);
