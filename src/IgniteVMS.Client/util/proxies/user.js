import axios from 'axios';

// READ
export const login = async user => await axios.post('/api/user/login', user);