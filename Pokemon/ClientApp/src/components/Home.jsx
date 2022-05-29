import React, { useState, useEffect } from 'react';
import { Container } from 'reactstrap';
import SearchPokemon from './SearchPokemon';
import styled from 'styled-components';

const Home = () => {
  const [result, setResult] = useState();

  useEffect(() => {
    console.log(result);
  }, [result]);

  return (
    <StyledContainer>
      <h1>Pokemon search engine</h1>
      <p>Enter a pokemon name to find out more details...</p>
      <SearchPokemon onSetResult={setResult} />
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
