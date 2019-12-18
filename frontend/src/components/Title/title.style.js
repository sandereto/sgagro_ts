import styled from "styled-components";
import variaveis from "../../styles/variaveis.scss";

export const TitleStyle = styled.h5`
  && {
    font-size: 21px;
    color: ${variaveis.textDark};
    padding-top: 2%;
    padding-bottom: 1%;
    font-family: ${variaveis.fontFamilyTitles};
    font-weight: bold;
    &:after {
      content:' ';
      display:block;
      border:2px solid #d0d0d0;
      border-radius:4px;
      -webkit-border-radius:4px;
      -moz-border-radius:4px;
      box-shadow:inset 0 1px 1px rgba(0, 0, 0, .05);
      -webkit-box-shadow:inset 0 1px 1px rgba(0, 0, 0, .05);
      -moz-box-shadow:inset 0 1px 1px rgba(0, 0, 0, .05);
  }
  }
`;
