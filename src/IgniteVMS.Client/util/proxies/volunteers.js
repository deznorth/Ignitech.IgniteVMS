import axios from 'axios';

// READ
export const getAllVolunteerIDs = async () => await axios.get('/api/volunteers'); // This is an example endpoint, remove when the real ones are created