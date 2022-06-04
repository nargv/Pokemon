import React from 'react';
import { Container } from 'reactstrap';
import Text from '../defaultComponents/Text';
import styled from 'styled-components';

const SearchResult = (props) => {

    const getNoResults = () => {
        return (
            <Text type={"medium"} isWarning={true}>No Results.</Text>
        );
    }

    const getResults = () => {
        return (
            <div>
                <img 
                    src={props.result.sprite}
                    alt="new"
                />
                <Text type={"medium"}>{props.result.name}</Text>
                <Text type={"medium"}>{props.result.description}</Text>
            </div>
        );
    }

    return (
        <StyledContainer>
            {props.result ? getResults() : getNoResults()}
        </StyledContainer>
    );
}

export default SearchResult;

const StyledContainer = styled(Container)`
    margin-top: 40px;
    margin-bottom: 40px;
    height: fit-content;
    text-align: center;
    border: 2px solid grey;
    border-radius: 4px;
    display: block;
    margin-left: auto;
    margin-right: auto;
    width: 100%;
`;