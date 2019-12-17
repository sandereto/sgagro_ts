import api from './api';

export default {
	login(username, password) {
		return api.post(`/api/Login/TokenAsync`, { username, password });
	},
};
