import axios from 'axios';

// READ
export const postLogin = async (userData) => await axios.post('/api/auth/login', userData); 
export const getAllVolunteers = async () => await axios.get('/api/volunteers'); 