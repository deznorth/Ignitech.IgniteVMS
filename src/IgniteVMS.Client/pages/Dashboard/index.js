import React, { useEffect } from 'react';
import moment from 'moment';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { Button, Spinner } from 'react-bootstrap';
import { CalendarEvent } from 'react-bootstrap-icons';
import * as actions from './modules/actions';

import './styles.scss';

import LabeledNumber from '../../components/LabeledNumber';

const DashboardPage = props => {
  const {
    loading,
    metrics,
    fetchMetrics,
  } = props;

  const cn = 'dashboardpage';

  useEffect(() => {
    fetchMetrics();
  }, []);

  return (
    <div className={cn}>
      <div className={`${cn}_left`}>
        <h2>Volunteer Management</h2>
        <div className={`${cn}_card`}>
          <div className={`${cn}_card_header`}>
            <h4>Stats</h4>
            <Link to="/volunteers">
              <Button>Manage</Button>
            </Link>
          </div>
          <div className={`${cn}_card_body volunteermetrics`}>
            <LabeledNumber
              label="Pending"
              value={loading ? 0 : metrics.pendingVolunteers}
              path="/volunteers/pending"
            />
            <LabeledNumber
              label="Approved"
              value={loading ? 0 : metrics.approvedVolunteers}
              path="/volunteers/approved"
            />
            <LabeledNumber
              label="Denied"
              value={loading ? 0 : metrics.deniedVolunteers}
              path="/volunteers/denied"
            />
          </div>
        </div>
      </div>
      <div className={`${cn}_right`}>
        <h2>Opportunity Management</h2>
        <div className={`${cn}_card`}>
          <div className={`${cn}_card_header`}>
            <h4>Upcoming Opportunities</h4>
            <Link to="/opportunities">
              <Button>View All</Button>
            </Link>
          </div>
          <div className={`${cn}_card_body upcomingopportunities`}>
            {
              loading ? <Spinner animation="border" /> : (
                <table>
                  <tbody>
                    {
                      metrics.upcomingOpportunities.map(opportunity => (
                        <tr
                          key={opportunity.opportunityID}
                          className="upcomingopportunities_row"
                        >
                          <td className="upcomingopportunities_date" width="80px">
                            <CalendarEvent />
                            {moment(opportunity.startsAt).format('DD MMM')}
                          </td>
                          <td className="upcomingopportunities_title">
                            {opportunity.title}
                          </td>
                        </tr>
                      ))
                    }
                  </tbody>
                </table>
              )
            }
          </div>
        </div>
      </div>
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
