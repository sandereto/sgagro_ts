import styled from "styled-components";

export const HeaderStyle = styled.header`
  background-position: center;
  background-size: cover;
  background: ##45bb7e;
  display: flex;
  color: #fff;
  img {
    padding: 0.5rem;
    height: 50px;
    width: auto;
    cursor: pointer;
  }
  button {
    height: 100%;
    position: relative;
	border: none;
	background: none;
    
    span {
      position: relative;
    }
  }
`;
