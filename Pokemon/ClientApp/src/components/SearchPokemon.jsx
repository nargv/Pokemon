import React, { useEffect, useState } from 'react';
import Button from '../defaultComponents/Button';
import Input from '../defaultComponents/Input';
import SearchIcon from '@material-ui/icons/Search';
import { Container } from 'reactstrap';
import styled from 'styled-components';

const SearchPokemon = (props) => {
    const [searchInput, setSearchInput] = useState("");
    const [validEntry, setValidEntry] = useState(false);
    const [hideWarning, setHideWarning] = useState(true);
    const [isLoading, setIsLoading] = useState(false);

    const [width, setWidth] = useState(window.innerWidth);

    useEffect(() => {
        window.addEventListener('resize', updateWindowDimensions);

        return () => {
            window.removeEventListener('resize', updateWindowDimensions);
        }
    });

    const updateWindowDimensions = () => {
        setWidth(window.innerWidth);
    }

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
            await fetch(`pokemon/${searchInput}`)
                .then(response => {
                    if(response.ok)
                        return response.json();
                })
                .then(json => {
                    props.onSetResult(json);
                });
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
                <SearchIcon /> {width > 1000 && "Search"}
            </Button>
        </StyledContainer>
    );
}

export default SearchPokemon;

const StyledContainer = styled(Container)`
    flex-direction: row;
    flex-basis: unset;
    display: flex;
    justify-content: center;
`;