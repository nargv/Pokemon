import React, { useState } from 'react';
import Button from '../defaultComponents/Button';
import Input from '../defaultComponents/Input';
import SearchIcon from '@material-ui/icons/Search';
import { Container } from 'reactstrap';
import styled from 'styled-components';

const Search = () => {
    const [searchInput, setSearchInput] = useState("");

    const onValidation = (value) => {
        if(value === "") {
            return false;
        }
        return true;
    }

    return (
        <StyledContainer>
            <Input 
                onValidation={onValidation}
                onValueChange={setSearchInput}
                warningMessage={"search input is invalid"} 
            />
            <StyledButton>
                <SearchIcon /> Search
            </StyledButton>
        </StyledContainer>
    );
}

export default Search;

const StyledContainer = styled(Container)`
    flex-direction: row;
    flex-basis: unset;
    display: flex;
    justify-content: center;
`;

const StyledButton = styled(Button)`
    background: yellow;
`;