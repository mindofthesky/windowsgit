import Head from "../../components/commons/Headline/Head";
import ContactLevTwo from "./ContactLevTwo";
import ContactLevthr from "./ContactLevthr";
import {
  ContactContainer,
  ContactLayout,
  ContactMainBox,
  ContactMainWrap,
  HeadLineBox,
} from "../../styles/contact/contact";

const Contact = () => {
  return (
    <ContactLayout>
      <ContactContainer>
        <ContactMainWrap>
          <HeadLineBox>
            <Head content="Contact" color="sub" />
          </HeadLineBox>
          {/* 여기에 */}
          <ContactMainBox>
            <ContactLevthr />
            <ContactLevTwo />
          </ContactMainBox>
        </ContactMainWrap>
      </ContactContainer>
    </ContactLayout>
  );
};

export default Contact;
