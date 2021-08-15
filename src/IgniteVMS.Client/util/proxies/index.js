import * as MetricsProxy from './metrics';
import * as VolunteersProxy from './volunteers';

// Root Proxy
export default {
  ...MetricsProxy,
  ...VolunteersProxy,
};