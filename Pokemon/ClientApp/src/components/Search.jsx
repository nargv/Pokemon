import React, { useState } from 'react';
import Button from '../defaultComponents/Button';
import Input from '../defaultComponents/Input';
import SearchIcon from '@material-ui/icons/Search';
import { Container } from 'reactstrap';
import styled from 'styled-components';

const Search = () => {
    const [searchInput, setSearchInput] = useState("");
    const [validEntry, setValidEntry] = useState(false);
    const [hideWarning, setHideWarning] = useState(true);
    const [isLoading, setIsLoading] = useState(false);

    const onValidation = (value) => {
        if(value === "") {
            setValidEntry(false);
            setHideWarning(false);
            return;
        }
        setValidEntry(true);
        setHideWarning(true);
        setSearchInput(value);
    }

    const handleOnSearch = async () => {
        if(!validEntry) {
            setHideWarning(false);
        } else {
            setIsLoading(true);
            const result = await fetch(`pokemon/${searchInput}`);
            setIsLoading(false);
        }
    }

    return (
        <StyledContainer>
            <Input
                onValidation={onValidation}
                onValueChange={setSearchInput}
                warningMessage={"search input is invalid"} 
                hideWarning={hideWarning}
            />
            <Button handleOnClick={handleOnSearch} isLoading={isLoading}>
                <SearchIcon /> Search
            </Button>
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