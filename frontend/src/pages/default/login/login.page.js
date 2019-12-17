import React, { Component, Fragment } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import Title from '../../../components/Title/title.component';
import { CardStyle, LoginStyle, FormStyle } from './login.style';
import { Formik, Field, ErrorMessage } from 'formik';
import { LoginSchema } from "./login.validates";
import loginService from '../../../services/loginService';
import { isAuthenticated, setToken } from '../../../services/auth';

class Login extends Component {
	constructor(props){
		super(props)
		this.onSubmit = this.onSubmit.bind(this);
		const { history } = this.props;
		this.history = history;
		if (isAuthenticated()) {
			this.history.push('/home');
		}
	}

	async onSubmit(values){
		try {
			const { data } = await loginService.login(values.username, values.password);
			setToken(data.token);
			this.history.push('/home');
		} catch (error) {
			this.setState({
				error:
					'Houve um problema com o login, verifique suas credenciais. T.T',
			});
		}
	}

	render() {
		return (
			<Fragment>
				<Title>
					<div className='row'>
						<div className='col-10'>Autenticação</div>
					</div>
				</Title>
				<LoginStyle className='justify-content-center align-items-center'>
					<CardStyle className='justify-content-center'>
						<Formik
						  initialValues={{
							username: '',
							password: ''
						  }}
						  validationSchema={LoginSchema}
						  onSubmit={this.onSubmit}
						>
							{({ touched, errors, handleSubmit }) => (
								<FormStyle onSubmit={handleSubmit}>
								  <div className="form-group">
									  <label htmlFor="username" className="bmd-label-floating">Login</label>
									  <Field autoComplete="off" name="username" type="text" className={'form-control' + (errors.username && touched.username ? ' is-invalid' : '')} />
									  <ErrorMessage name="username" component="div" className="invalid-feedback" />
								  </div>
								  <div className="form-group">
									  <label htmlFor="password" className="bmd-label-floating">Senha</label>
									  <Field autoComplete="off" name="password" type="password" className={'form-control' + (errors.password && touched.password ? ' is-invalid' : '')} />
									  <ErrorMessage name="password" component="div" className="invalid-feedback" />
								  </div>
								  <div className="form-group">
									  <button type="submit" className="btn btn-lg btn-block btn-outline-secondary">Entrar</button>
								  </div>
							  </FormStyle>
							)}
						</Formik>
					</CardStyle>
				</LoginStyle>
			</Fragment>
		);
	}
}

const mapStateToProps = state => ({});

export default connect(mapStateToProps)(withRouter(Login));
