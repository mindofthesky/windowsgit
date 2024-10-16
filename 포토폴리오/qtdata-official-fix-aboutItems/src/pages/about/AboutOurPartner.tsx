import Head from "../../components/commons/Headline/Head";
import { partnerItems } from "../../datas/partnersItems";
import {
  PartnerImg,
  PartnerWrap,
  Partners,
  HiddenDiv,
} from "../../styles/about/aboutOurPartnerStyle";

const AboutOurPartner = () => {
  return (
    <PartnerWrap>
      <HiddenDiv />
      <Head content="Our Partners" color="sub" />
      <Partners>
        {partnerItems.map((item, index) => (
          <PartnerImg key={index} src={item.partnerSrc} alt={item.partnerAlt} />
        ))}
      </Partners>
    </PartnerWrap>
  );
};

export default AboutOurPartner;
