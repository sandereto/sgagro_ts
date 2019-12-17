import styled from "styled-components";
import variaveis from "../../../styles/variaveis.scss";

export const HomeStyle = styled.div`
&& {
	width: auto;
	height: 400px;
}
`;

export const CardStyle = styled.div`
	.card {
		cursor: pointer;
		color: #212529;
		width: 150px;
		word-wrap: break-word;
	}
	.card:hover {
		background-color: #e2e0e0;
	}
	a, a:hover {
		color: #212529;
		text-decoration: none;
	}
	.far, .fal {
		font-size: 45px;
	}
	.card-body {
		width: 100%;
		color: #fff;
		background-color: ${variaveis.primaryColor};
		padding: 0.25rem;
		height: 68px;
	}
`;
