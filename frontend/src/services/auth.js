import * as jwtDecode from 'jwt-decode';

export const TOKEN_KEY = '@projeto-token';

export const getToken = () => localStorage.getItem(TOKEN_KEY);

export const getTokenDecoded = () => {
	let tokenDecoded;

	try {
		tokenDecoded = jwtDecode(getToken());
	} catch {
		return '';
	}

	return tokenDecoded;
};

export const isAuthenticated = () => {
	if (getToken() !== null) {
		const tokenDecoded = getTokenDecoded();

		if (tokenDecoded instanceof Object) {
			const now = new Date().getTime();
			return tokenDecoded.exp > now / 1000;
		}
	}

	return false;
};

export const setToken = (token) => {
	localStorage.setItem(TOKEN_KEY, token);
};

export const removeToken = () => {
	localStorage.removeItem(TOKEN_KEY);
};

export const getUsername = () => getTokenDecoded().name;
