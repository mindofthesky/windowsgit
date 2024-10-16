import React from "react";
import Text from "../Text/Text";
import { TextProps } from "../../../types";
import { Headline } from "./headstyle";
import { useTheme } from "styled-components";

const Head: React.FC<TextProps> = (props) => {
  const theme = useTheme();
  const { content } = props;
  return (
    <>
      <Headline>
        <Text content={content} color={theme.colors.sub} />
      </Headline>
    </>
  );
};

export default Head;
