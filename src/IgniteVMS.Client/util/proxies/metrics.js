import axios from 'axios';

// READ
export const getMetrics = async () => await axios.get('/api/metrics');