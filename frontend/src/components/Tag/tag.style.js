import { Button } from 'reactstrap';
import styled from 'styled-components';
import variaveis from '../../styles/variaveis.scss';

// $apontamento: #9cedfc !default;
// $protesto: #dc3545 !default;
// $intimacao: #0a7fc2 !default;
// $cancelamento: #ac0707 !default;
// $liquidacao: #05a182 !default;
// $devolucao: #46637f !default;
// $retirada: #5b2fa3 !default;
// $sustacao: #fd7e14 !default;
// $suspensao: #da690b !default;
// $cetidao: #6f42c1 !default;

export const TagStyle = styled.div`
  && {
	display: inline-block;
    min-width: 10px;
    padding: 7px 7px;
    font-size: 12px;
    font-weight: 700;
    color: #fff;
    line-height: 1;
    vertical-align: baseline;
    white-space: nowrap;
    text-align: center;
	border-radius: 10px; 
	background-color: #ccc;
	${({ tipo }) => (tipo === 'apontamento') && `
		background-color: ${variaveis.apontamento}
	`};

	${({ tipo }) => (tipo === 'cancelamento') && `
		background-color: ${variaveis.cancelamento}
	`};
  }
`;