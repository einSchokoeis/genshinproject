from kivy.lang import Builder
from kivy.uix.boxlayout import BoxLayout
from kivy.properties import ObjectProperty
from kivymd.uix.dialog import MDDialog
from kivymd.uix.button import MDFlatButton

from kivymd.app import MDApp

KV = '''
<ContentNavigationDrawer>:

    ScrollView:

        MDList:

            OneLineListItem:
                text: "Venti"
                on_press:
                    root.nav_drawer.set_state("close")
                    root.screen_manager.current = "venti"

            OneLineListItem:
                text: "mona"
                on_press:
                    root.nav_drawer.set_state("close")
                    root.screen_manager.current = "scr 2"


Screen:

    in_class: atk

    MDToolbar:
        id: toolbar
        pos_hint: {"top": 1}
        elevation: 10
        title: "Characters"
        left_action_items: [["menu", lambda x: nav_drawer.set_state("open")]]

    MDNavigationLayout:
        x: toolbar.height
        id: navi

        ScreenManager:
            id: screen_manager

            Screen:



                name: "venti"

                MDLabel:
                    text: "Screen 1"
                    halign: "center"

                MDTextField:
                    hint_text: "atk"
                    pos_hint: {"center_x":0.5, "center_y": 0.3}
                    width: 300
                    id: atk

                MDRectangleFlatButton:
                    text: 'Submit'
                    pos_hint: {'center_x': 0.5, 'center_y': 0.3}
                    on_press:
                        app.ref_atk()
                MDLabel:
                    text: ''
                    id: show
                    pos_hint: {'center_x': 1.0, 'center_y': 0.2}



                MDChip:
                    text: "viriscendent"
                    check: True
                    halign: "center"
                    on_release: app.add_arti(self)


            Screen:
                name: "scr 2"

                MDLabel:
                    text: "Screen 2"
                    halign: "center"

        MDNavigationDrawer:
            id: nav_drawer

            ContentNavigationDrawer:
                screen_manager: screen_manager
                nav_drawer: nav_drawer
'''




class ContentNavigationDrawer(BoxLayout):
    screen_manager = ObjectProperty()
    nav_drawer = ObjectProperty()

class character:
    def __init__(self, patk, p_e_dmg_type, p_ult_dmg_type, p_e_dmg, p_ult_dmg):
        self.atk = patk
        self.e_dmg_type = p_e_dmg_type
        self.ult_dmg_type = p_ult_dmg_type
        ult_dmg = p_ult_dmg
        e_dmg = p_e_dmg
    def schaden(self, arti, arti2):
        return (self.atk * arti.dmg_bonus)



    def e_dmg(self, perc):
        return perc * self.atk

class artifactsets:
    def __init__(self, p_dmg_type, pEM, patkp, p_dmg_bonus, p_el_dmg_bonus, p_elr_bonus):
        dmg_type = p_dmg_type
        EM = pEM
        atkpr = (100 + patkp)/100
        dmg_bonus = (100+p_dmg_bonus) / 100
        el_dmg_bonus = p_el_dmg_bonus
        elr_bonus = (100+ p_elr_bonus) / 100

class elements:
    x = 1

anemo = elements()
geo = elements()
pyro = elements()
electro = elements()
kryo = elements()
hydro = elements()
dendro = elements()



venti = character(1, anemo, anemo, 50, 100)


viriscendent1 = artifactsets(anemo, 0, 0, 0, 15, 0)
viriscendent2 = artifactsets(anemo, 0, 0, 0, 0, 60)

class TestNavigationDrawer(MDApp):
    moment_arti = None
    moment_arti2 = None
    atk = 0

    in_class = ObjectProperty(None)
    def ref_atk(self):
        self.atk = self.root.in_class
        TestNavigationDrawer.uwu()
    def uwu(self):
        self.dialog = MDDialog(title="dein dmg :3", text = venti.schaden(self.moment_arti,self.moment_arti2), size_hint=(0.8, 1), buttons=[MDFlatButton(text='Close', on_release=self.close_dialog),
                                            MDFlatButton(text='More')])
        self.dialog.open()
    def close_dialog(self, obj):
        self.dialog.dismiss()

    def add_arti(self, instance):
        moment_arti = viriscendent1
        moment_arti2 = viriscendent2
        print(instance)

    def build(self):
        return Builder.load_string(KV)


TestNavigationDrawer().run()
