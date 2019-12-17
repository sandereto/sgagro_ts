import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import Content from "../../../components/Layout/Content/content.component";
import Footer from "../../../components/Layout/Footer/footer.component";
import Header from "../../../components/Layout/Header/header.component";
import ToastHelper from '../../../utils/toastHelper';
import { removeToken,  getUsername } from '../../../services/auth';
import { LoadingStyle } from "./layout.style";
import Menu from '../../../components/Menu/menu';

const mapStateToProps = state => ({
	loading: state.loading
});

class LayoutContainer extends Component {
	constructor(props){
		super(props)
		const { history } = this.props;
		this.history = history;
	}
	componentDidMount() {
		ToastHelper.create();
	}

	logout(){
		removeToken();
		window.location.href = "/"
	}

	render() {
		const { children, loading } = this.props;
		return (
			<Fragment>
				<Fragment>
					<Fragment>
						<Menu/>
						<Header logout={()=>this.logout()} username={getUsername()} />
						<Content>{children}</Content>
						<Footer />
					</Fragment>
					{loading.loading && (
						<LoadingStyle className="loading">
							<div className="text-center">
								<div className="spinner-border" role="status">
									<span className="sr-only">Loading...</span>
								</div>
							</div>
						</LoadingStyle>
					)}
				</Fragment>
			</Fragment>
		);
	}
}

export default connect(
	mapStateToProps,
	null,
)(LayoutContainer);
