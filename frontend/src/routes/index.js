import { createHashHistory } from 'history';
import React from 'react';
import { Router, Route, Switch, Redirect } from 'react-router-dom';
import Login from '../pages/default/login/login.page';
import Home from '../pages/default/home/home.page';
import ApontamentoColaborador from '../pages/apontamento_colaboradores/apontamento_colaborador.page';
import { isAuthenticated } from '../services/auth';
import LayoutContainer from '../pages/default/layout/layout.container';
import LayoutLoginContainer from '../pages/default/layout/layoutLogin.container';

export const history = createHashHistory();

const PrivateRoute = ({ component: Component, ...rest }) => (
	<Route
		{...rest}
		render={props => (isAuthenticated() ? (
			<Component {...props} />
		) : (
			<Redirect to={{ pathname: '/login', state: { from: props.location } }} />
		))
		}
	/>
);

const LoginContainer  = ()=> <LayoutLoginContainer><Login/></LayoutLoginContainer>

const Routes = () => (
	<Router history={history}>
		<Switch>
		    <Route exact path='/login' component={LoginContainer} />
			<LayoutContainer>
				<PrivateRoute  path='/' component={Home} />
				<PrivateRoute  path='/apontamento' component={ApontamentoColaborador} />
			</LayoutContainer>
		</Switch>
	</Router>
);

export default Routes;
