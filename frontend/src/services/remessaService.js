import api from './api';

export default {
	upload(file) {
        const formData = new FormData();
		formData.append('file',file[0])
		const config = {
			headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
		};
		return api.post(`/api/Remessa`, formData, config);
	},
};
