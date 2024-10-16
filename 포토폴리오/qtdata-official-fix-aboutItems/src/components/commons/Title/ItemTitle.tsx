import React from "react";
import Text from "../Text/Text";
import { ItemTitleWrap } from "./titleStyle";

const ItemTitle: React.FC<{ content: string; styles: any }> = (props) => {
  const { content, styles } = props;
  return (
    <>
      <ItemTitleWrap>
        <Text
          content={content}
          color={styles.titleColor}
          fontWeight={styles.titleFontWeight}
          fontSize={styles.titleFontSize || "24px"}
          lineHeight={styles.titleLineHeight}
        />
      </ItemTitleWrap>
    </>
  );
};

export default ItemTitle;
