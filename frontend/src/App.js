import '@fortawesome/fontawesome-free/css/all.css';
import '@trendmicro/react-sidenav/dist/react-sidenav.css';
import React from 'react';
import { Provider } from 'react-redux';
import './config/ReactotronConfig';
import Routes from './routes';
import store from './store';
import './styles/main.scss';

const App = () => (
	<Provider store={store}>
		<Routes />
	</Provider>
);

export default App;
