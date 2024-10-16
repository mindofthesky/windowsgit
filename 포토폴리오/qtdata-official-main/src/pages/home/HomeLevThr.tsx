import HomeItemBox from "./HomeItemBox";
import { theme } from "../../themes/themes";
import { ThrItemBoxes } from "../../datas/homeItems";
import { HomeThrItems, HomeThrWrap } from "../../styles/home/homeLevThrStyle";

const titleStyles = {
  titleColor: theme.colors.sub,
  titleFontWeight: "700",
  titleLineHeight: "32px",
};

const HomeLevThr = () => {
  return (
    <HomeThrWrap>
      <HomeThrItems>
        {ThrItemBoxes.map((item) => (
          <HomeItemBox
            key={item.id}
            itemImgSrc={item.itemImgSrc}
            itemImgAlt={item.itemImgAlt}
            itemTitle={item.itemTitle.content}
            descContent={item.descContent}
            titleStyles={titleStyles}
            imageSize="48px"
          />
        ))}
      </HomeThrItems>
    </HomeThrWrap>
  );
};

export default HomeLevThr;
