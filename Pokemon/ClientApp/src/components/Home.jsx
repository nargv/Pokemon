import React from 'react';
import { Container } from 'reactstrap';
import Search from './Search';
import styled from 'styled-components';

const Home = () => {

  return (
    <StyledContainer>
      <h1>Pokemon search engine</h1>
      <p>Enter a pokemon name to find out more details...</p>
      <Search />
    </StyledContainer>
  );
}

export default Home;

const StyledContainer = styled(Container)`
  width: 50%;
  margin: 0 auto;
  text-align: center;
  margin-top: 40px;
`;
