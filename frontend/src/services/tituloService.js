import api from './api';

export default {
	filtro(filtro) {
		return api.post(`/api/Titulo`, filtro);
	},
};
