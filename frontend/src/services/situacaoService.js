import api from './api';

export default {
	lista() {
		return api.get(`/api/Situacao`);
	},
};
