import React from "react";
import Text from "../Text/Text";
import { TextProps } from "../../../types";

const Headline: React.FC<TextProps> = (props) => {
  const { content, color } = props;
  return (
    <>
      <div className="headline">
        <Text
          content={content}
          color={color}
          fontSize="60px"
          fontFamily="Montserrat"
          fontWeight="800"
          lineHeight="73px"
        />
      </div>
    </>
  );
};

export default Headline;
