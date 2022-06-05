import React, { useState } from 'react';
import { useSelector } from 'react-redux';
import { Container } from 'reactstrap';
import Text from '../defaultComponents/Text';
import SearchResult from './SearchResult';
import styled from 'styled-components';

const History = () => {
  const searches = useSelector(state => state.searches);

  const getSearches = () => {
    return (
      searches.searches.slice(0).reverse().map((item, index) => (<SearchResult key={index} result={item} />))
    );
  }

  return (
    <StyledContainer>
      <Text type={"large"}>HISTORY</Text>
      {searches.searches.length > 0 ? 
        getSearches()
        : 
        <Text type={"medium"}>No pokemon searches were made.</Text>
      }
    </StyledContainer>
  );
}

export default History;

const StyledContainer = styled(Container)`
  width: 80%;
  margin: 0 auto;
  text-align: center;
  margin-top: 40px;
`;
