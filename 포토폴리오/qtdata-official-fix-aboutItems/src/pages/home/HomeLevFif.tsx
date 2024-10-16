import HomeItemBox from "./HomeItemBox";
import { theme } from "../../themes/themes";
import { FifItemBoxes } from "../../datas/homeItems";
import { HomeFifItems, HomeFifWrap } from "../../styles/home/homeLevFifStyle";

const titleStyles = {
  titleColor: theme.colors.sub,
  titleFontWeight: "700",
  titleLineHeight: "32px",
  titleFontSize: "24px",
};

const HomeLevFif = () => {
  return (
    <HomeFifWrap>
      <HomeFifItems>
        {FifItemBoxes.map((item) => (
          <HomeItemBox
            key={item.id}
            itemImgSrc={item.itemImgSrc}
            itemImgAlt={item.itemImgAlt}
            itemTitle={item.itemTitle.content}
            descContent={item.descContent}
            titleStyles={titleStyles}
            imageSize="150px"
          />
        ))}
      </HomeFifItems>
    </HomeFifWrap>
  );
};

export default HomeLevFif;
