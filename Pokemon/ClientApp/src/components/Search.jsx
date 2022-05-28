import React, { useState } from 'react';
import Input from '../defaultComponents/Input';

const Search = () => {
    const [searchInput, setSearchInput] = useState("");

    const onValidation = (value) => {
        if(value === "") {
            return false;
        }
        return true;
    }

  return (
    <div>
        <Input 
            label={"Search"}
            onValidation={onValidation}
            onValueChange={setSearchInput}
            warningMessage={"search input is invalid"} 
        />
    </div>
  );
}

export default Search;