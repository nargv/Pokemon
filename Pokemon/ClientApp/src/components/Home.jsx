import React, { useState, useRef, useEffect } from 'react';
import { Container } from 'reactstrap';
import SearchPokemon from './SearchPokemon';
import styled from 'styled-components';
import SearchResult from './SearchResult';
import Text from '../defaultComponents/Text';
import { useDispatch } from 'react-redux';
import { addSearch } from '../searches';

const Home = () => {
  const dispatch = useDispatch();

  const [result, setResult] = useState();
  const [displayResults, setDisplayResults] = useState(false);

  const handleOnSetResult = (value) => {
    if(value) {
      dispatch(addSearch(value));
    }
    setResult(value);
    setDisplayResults(true);
  }

  return (
    <StyledContainer>
      <Text type={"large"}>Pokémon search engine</Text>
      <Text type={"medium"}>Enter a Pokémon name to find out more details...</Text>
      <SearchPokemon onSetResult={handleOnSetResult} />
      {displayResults && <SearchResult result={result} />}
    </StyledContainer>
  );
}

export default Home;

const StyledContainer = styled(Container)`
  width: 80%;
  margin: 0 auto;
  text-align: center;
  margin-top: 40px;
`;
