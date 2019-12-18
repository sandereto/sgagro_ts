
import axios from 'axios';
import store from '../store';
import ToastHelper from '../utils/toastHelper';
import loadingService from './loadingService';
import * as Contansts from '../constants';

const api = axios.create({
	baseURL: '/',
});

const showLoading = () => {
	store.dispatch(loadingService.showLoading());
};

const hideLoading = () => {
	store.dispatch(loadingService.hideLoading());
};

api.interceptors.request.use(
	(config) => {
		showLoading();
		return config;
	},
	(error) => {
		hideLoading();
		return Promise.reject(error);
	},
);

api.interceptors.response.use(
	(response) => {
		hideLoading();
		return response;
	},
	(error) => {
		hideLoading();
		if (error.response.data.status === Contansts.STATUS_HTTP_ERRO_INTERNO) {
			ToastHelper.error('Ocorreu um erro no sistema, contate o administrador do sistema.');
		}

		return Promise.reject(error);
	},
);

export default api;
